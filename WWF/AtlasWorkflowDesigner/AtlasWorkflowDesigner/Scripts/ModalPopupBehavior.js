// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.


Type.registerNamespace('AtlasControlToolkit');
AtlasControlToolkit.ModalPopupBehavior = function() {
    AtlasControlToolkit.ModalPopupBehavior.initializeBase(this);

    //
    // Variables
    //

    // Custom properties
    var _PopupControlID;
    var _BackgroundCssClass;
    var _DropShadow = false;
    var _OkControlID;
    var _CancelControlID;
    var _OnOkScript;
    var _OnCancelScript;

    // Member variables
    var _backgroundElement;
    var _foregroundElement;
    var _showHandler;
    var _okHandler;
    var _cancelHandler;
    var _scrollHandler;
    var _resizeHandler;
    
    var _foregroundElementControl;
    var _dropShadowBehavior;

    //
    // Overrides
    //

    this.initialize = function() {
        AtlasControlToolkit.ModalPopupBehavior.callBaseMethod(this, 'initialize');

        _backgroundElement = document.createElement('div');
        _backgroundElement.style.display = 'none';
        _backgroundElement.style.position = 'absolute';
        if (_BackgroundCssClass) {
            _backgroundElement.className = _BackgroundCssClass;
        }
        document.body.appendChild(_backgroundElement);

        _foregroundElement = $(_PopupControlID);
        _foregroundElement.style.display = 'none';
        _foregroundElement.style.position = 'absolute';
        document.body.appendChild(_foregroundElement);

        // Note: Safari doesn't support cancellation of link clicks added by
        // addEventListener, so we must add them with "onclick ="

        _showHandler = Function.createDelegate(this, this._onShow);
        if (window.__safari) {
            this.control.element.onclick = _showHandler;
        } else {
            this.control.element.attachEvent('onclick', _showHandler);
        }

        if (_OkControlID) {
            _okHandler = Function.createDelegate(this, this._onOk);
            if (window.__safari) {
                $(_OkControlID).onclick = _okHandler;
            } else {
                $(_OkControlID).attachEvent('onclick', _okHandler);
            }
        }

        if (_CancelControlID) {
            _cancelHandler = Function.createDelegate(this, this._onCancel);
            if (window.__safari) {
                $(_CancelControlID).onclick = _cancelHandler;
            } else {
                $(_CancelControlID).attachEvent('onclick', _cancelHandler);
            }
        }

        _scrollHandler = Function.createDelegate(this, this._onLayout);
        _resizeHandler = Function.createDelegate(this, this._onLayout);

        _foregroundElementControl = new Sys.UI.Control(_foregroundElement);
    }

    this.dispose = function() {
        this._detachPopup();
        _scrollHandler = null;
        _resizeHandler = null;

        if (_foregroundElementControl) {
            _foregroundElementControl.dispose();
            _foregroundElementControl = null;
        }

        
        if (_cancelHandler) {
            $(_CancelControlID).detachEvent('onclick', _cancelHandler);
            _cancelHandler = null;
        }

        if (_okHandler) {
            $(_OkControlID).detachEvent('onclick', _okHandler);
            _okHandler = null;
        }

        if (_showHandler) {
            this.control.element.detachEvent('onclick', _showHandler);
            _showHandler = null;
        }

        AtlasControlToolkit.ModalPopupBehavior.callBaseMethod(this, 'dispose');
    }

    this.getDescriptor = function() {
        var td = AtlasControlToolkit.ModalPopupBehavior.callBaseMethod(this, 'getDescriptor');

        //  Add property declarations
        td.addProperty('PopupControlID', String);
        td.addProperty('BackgroundCssClass', String);
        td.addProperty('DropShadow', Boolean);
        td.addProperty('OkControlID', String);
        td.addProperty('CancelControlID', String);
        td.addProperty('OnOkScript', String);
        td.addProperty('OnCancelScript', String);

        return td;
    }

    //
    // Custom methods
    //

    this._attachPopup = function() {
        if (_DropShadow) {
            _dropShadowBehavior = new AtlasControlToolkit.DropShadowBehavior();
            _foregroundElementControl.get_behaviors().add(_dropShadowBehavior);
            _dropShadowBehavior.initialize();
        }

        window.attachEvent('onresize', _resizeHandler);
        window.attachEvent('onscroll', _scrollHandler);
    }

    this._detachPopup = function() {
        if (_scrollHandler) {
            window.detachEvent('onscroll', _scrollHandler);
        }
        
        if (_resizeHandler) {
            window.detachEvent('onresize', _resizeHandler);
        }

        if (_dropShadowBehavior) {
            _dropShadowBehavior.dispose();
            _foregroundElementControl.get_behaviors().remove(_dropShadowBehavior);
            _dropShadowBehavior = null;
        }
    }

    this._onShow = function(e) {
        this._show();
        event.returnValue = false;
        return false;
    }

    this._onOk = function() {
        this._hide();
        event.returnValue = false;
        if (_OnOkScript) {
            window.setTimeout(_OnOkScript, 0);
        }
        return false;
    }

    this._onCancel = function() {
        this._hide();
        event.returnValue = false;
        if (_OnCancelScript) {
            window.setTimeout(_OnCancelScript, 0);
        }
        return false;
    }

    this._onLayout = function() {
        this._layout();
    }

    this._show = function() {
        this._attachPopup();

        _backgroundElement.style.display = '';
        _foregroundElement.style.display = '';

        this._layout();
        // On pages that don't need scrollbars, Firefox and Safari act like
        // one or both are present the first time the layout code runs which
        // obviously leads to display issues - run the layout code a second
        // time to work around this problem
        this._layout();
    }

    this._hide = function() {
        _backgroundElement.style.display = 'none';
        _foregroundElement.style.display = 'none';

        this._detachPopup();
    }

    this._layout = function() {
        var scrollLeft = (document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft);
        var scrollTop = (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);
        var clientWidth;
        if (window.innerWidth) {
            clientWidth = (window.__safari ? window.innerWidth : Math.min(window.innerWidth, document.documentElement.clientWidth));
        } else {
            clientWidth = document.body.offsetWidth;//document.documentElement.clientWidth;
        }
        var clientHeight;
        if (window.innerHeight) {
            clientHeight = (window.__safari ? window.innerHeight : Math.min(window.innerHeight, document.documentElement.clientHeight));
        } else {
            clientHeight =  document.body.offsetHeight;//document.documentElement.clientHeight;
        }

        _backgroundElement.style.left = scrollLeft+'px';
        _backgroundElement.style.top = scrollTop+'px';
        _backgroundElement.style.width = clientWidth+'px';
        _backgroundElement.style.height = clientHeight+'px';
        _foregroundElement.style.left = scrollLeft+((clientWidth-_foregroundElement.offsetWidth)/2)+'px';
        _foregroundElement.style.top = scrollTop+((clientHeight-_foregroundElement.offsetHeight)/2)+'px';

        if (_dropShadowBehavior) {
            _dropShadowBehavior.setShadow();
            window.setTimeout(Function.createDelegate(this, this._fixupDropShadowBehavior), 0);
        }
    }

    // Some browsers don't update the location values immediately, so
    // the location of the drop shadow would always be a step behind
    // without this method
    this._fixupDropShadowBehavior = function() {
        if (_dropShadowBehavior) {
            _dropShadowBehavior.setShadow();
        }
    }

    //
    // Property get/set methods
    //

    this.get_PopupControlID = function() {
        return _PopupControlID;
    }

    this.set_PopupControlID = function(value) {
        _PopupControlID = value;
    }

    this.get_BackgroundCssClass = function() {
        return _BackgroundCssClass;
    }

    this.set_BackgroundCssClass = function(value) {
        _BackgroundCssClass = value;
    }

    this.get_DropShadow = function() {
        return _DropShadow;
    }

    this.set_DropShadow = function(value) {
        _DropShadow = value;
    }

    this.get_OkControlID = function() {
        return _OkControlID;
    }

    this.set_OkControlID = function(value) {
        _OkControlID = value;
    }

    this.get_CancelControlID = function() {
        return _CancelControlID;
    }

    this.set_CancelControlID = function(value) {
        _CancelControlID = value;
    }

    this.get_OnOkScript = function() {
        return _OnOkScript;
    }

    this.set_OnOkScript = function(value) {
        _OnOkScript = value;
    }

    this.get_OnCancelScript = function() {
        return _OnCancelScript;
    }

    this.set_OnCancelScript = function(value) {
        _OnCancelScript = value;
    }
}

AtlasControlToolkit.ModalPopupBehavior.registerSealedClass('AtlasControlToolkit.ModalPopupBehavior', Sys.UI.Behavior);
Sys.TypeDescriptor.addType('script', 'modalPopupBehavior', AtlasControlToolkit.ModalPopupBehavior);
