using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

//Note use of Interop wrapper
using SpeechLib;

namespace SpeechRecognition
{
    public partial class Form1 : Form
    {
        //The Speech recognizer
        SpInprocRecognizer recognizer;

        //The grammar that we're recognizing
        ISpeechRecoGrammar grammar;


        //The filestream containing the speec
        SpFileStream fileStream;

        //The recognizer context
        SpInProcRecoContext speechRecoContext;


        public Form1()
        {
            InitializeComponent();
        }

        private void openWAVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Standard dialog
            OpenFileDialog ofd = new OpenFileDialog();

            //Restrict to .wav files
            ofd.DefaultExt = ".wav";
            ofd.Filter = ".WAV files (.wav)|*.wav";
            //N.B.: 1-based index!
            ofd.FilterIndex = 1; 

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Transcribe selected .WAV file
                TranscribeAudioFile(ofd.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void TranscribeAudioFile(string fName)
        {
            //Create the recognizer
            recognizer = new SpInprocRecognizer();

            //Recognize the speec in the file that we passed in
            fileStream = new SpFileStream();
            fileStream.Open(fName, SpeechStreamFileMode.SSFMOpenForRead, true);
            recognizer.AudioInputStream = fileStream;

            //Create a recognition context
            speechRecoContext = (SpInProcRecoContext)recognizer.CreateRecoContext();

            //Wire up events to handlers
            speechRecoContext.Hypothesis += new _ISpeechRecoContextEvents_HypothesisEventHandler(OnHypothesis);
            speechRecoContext.Recognition += new _ISpeechRecoContextEvents_RecognitionEventHandler(OnRecognition);
            speechRecoContext.EndStream += new _ISpeechRecoContextEvents_EndStreamEventHandler(OnAudioStreamEnd);

            //Create standard grammar
            grammar = speechRecoContext.CreateGrammar(10);
            try
            {
                //Begin recognition as soon as dictation (in this case, file playback) is begun 
                grammar.DictationSetState(SpeechRuleState.SGDSActive);
            }
            catch (System.Runtime.InteropServices.COMException ce)
            {
                Debug.WriteLine(ce.ToString());
            }
        }

        //This will be called many times, as data is analyzed
        void OnHypothesis(int StreamNumber, object StreamPosition, ISpeechRecoResult Result)
        {
            lock (this)
            {
                ISpeechPhraseInfo info = Result.PhraseInfo;
                //You could, of course, store this for further processing / analysis
                foreach (ISpeechPhraseElement el in info.Elements)
                {
                    Debug.WriteLine(el.DisplayText);
                }
                Debug.WriteLine("--Hypothesis over--");
            }
        }

        //This will be called once, after entire file is analyzed
        void OnRecognition(int StreamNumber, object StreamPosition, SpeechRecognitionType RecognitionType, ISpeechRecoResult Result)
        {
            ISpeechPhraseInfo phraseInfo = Result.PhraseInfo;
            //The best guess at the completely recognized text
            string s = phraseInfo.GetText(0, -1, true);
            richTextBox1.AppendText(s);

            //Or you could look at alternates. Here, request up to 10 alternates from index position 0 considering all elements (-1)
            foreach(ISpeechPhraseAlternate alternate in Result.Alternates(10, 0, -1))
            {
                ISpeechRecoResult altResult = alternate.RecoResult;
                ISpeechPhraseInfo altInfo = altResult.PhraseInfo;
                string altString = altInfo.GetText(0, -1, true);
                Debug.WriteLine(altString);
            }
        }

        void OnAudioStreamEnd(int StreamNumber, object StreamPosition, bool someBool)
        {
            //Stop recognition
            grammar.DictationSetState(SpeechRuleState.SGDSInactive);
            //Unload the active dictation topic
            grammar.DictationUnload();
        }
    }
}