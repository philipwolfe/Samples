
//Copyright (c) 2006 Jon Flanders - http://www.masteringbiztalk.com/
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
//associated documentation files (the "Software"), to deal in the Software without restriction, 
//including without limitation the rights to use, copy, modify, merge, publish, distribute, 
//sublicense, and/or sell copies of the Software, and to permit persons to whom the Software 
//is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included 
//in all copies or substantial portions of the Software.
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
//INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
//PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
//FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.



Type.registerNamespace('Flanders.UI.Web.Atlas');

Flanders.UI.Web.Atlas.DesignerImage = function() {
    Flanders.UI.Web.Atlas.DesignerImage.initializeBase(this);
    this.initialize = function() {
        _baseurl = "wfimages/test.png";//TODO:WHy not being set?
        Flanders.UI.Web.Atlas.DesignerImage.callBaseMethod(this, 'initialize'); 
        var _click = Function.createDelegate(this,this.click);
        var _context  = Function.createDelegate(this,displaymenu);
        var _mouseover  = Function.createDelegate(this,this.mouseover); 
        var _mousemove  = Function.createDelegate(this,this.mousemove);
        var _load  = Function.createDelegate(this,this.imageLoad);
        var _mouseup = Function.createDelegate(this,this.mouseup);
        var _blur  = Function.createDelegate(this,this.blur);
        var _windowmousemove = Function.createDelegate(this,this.windowmousemove);
        window.attachEvent("onmouseup",_windowmousemove);
        this.control.element.attachEvent("onblur",_blur);
        this.control.element.attachEvent("onmouseup",_mouseup);
        this.control.element.attachEvent("oncontextmenu", _context);
        this.control.element.attachEvent("onclick", _click);
        this.control.element.attachEvent("onmouseover", _mouseover);
        this.control.element.attachEvent("onmousemove",_mousemove);
        this.control.element.attachEvent("onload",_load);
        Sys.UI.DragDropManager.registerDropTarget(this);   
        
    }
    this.showView = function(act,view)
    {
        var p  = act + '|' + view;
        WorkflowAtlasDesigner.ImageService.ImageOperation(this.control.element.id,"ChangeView",p,x,y,requestCompleted,OnTimeout);
   
       
    }
    
    this.blur = function()
    {
        var e = window.event;
        //debug.trace('blur ' + e.offsetX + ' ' + e.offsetY );
    }
    this.mouseup = function()
    {   
        var e = window.event;
       //debug.trace('mouseup ' + e.offsetX + ' ' + e.offsetY );
    }
     this.dropped = this.createEvent();
    
    this.addActivity = function(id,act, x, y)
    {
	      WorkflowAtlasDesigner.ImageService.ImageOperation(id,"Add",act,x,y,requestCompleted,OnTimeout);
   
    }
    this.click  = function()
    {
    
        this.mouseover();
        var e = window.event;
        var x = Math.abs(e.offsetX);
        var y = Math.abs(e.offsetY);

        if($('data').value!="")
        {
            var data = $('data').value;
            if(data!="")
            {
                this.addActivity(this.control.element.id,data,x,y);
                $('data').value = "";
            }
        }
        var hotspot = HitTest(e.offsetX ,e.offsetY);
        if(hotspot!=null)
        {
            
            _propertyHotspot = hotspot;
            Sys.TypeDescriptor.invokeMethod(this,hotspot.Cmd.Name,hotspot.Cmd.Args);
         }
        if (typeof el!="undefined" && contextisvisible)
        {
            el.style.visibility="hidden";
            contextisvisible=0;
        }
        //
       
    }
    var _propertyHotspot;
    this.getProperties = function(act)
    {
        var hotspot = _propertyHotspot.Name;
        //debug.trace('getting properties for ' + hotspot);
        WorkflowAtlasDesigner.ImageService.GetProperties(this.control.element.id,hotspot,this.propertiesCompleted,OnTimeout);
       WorkflowAtlasDesigner.ImageService.GetValidationErrors(this.gotErrors,OnTimeout);
    }
    this.gotErrors = function(result)
    {
        var d = $('errors');
        var newdiv = null;
        for(var i=0;i<d.children.length;i++)
            d.removeChild(d.children[i]);
        for(var i=0;i<result.length;i++)
        {
            newdiv = document.createElement('div');
            newdiv.innerText = result[i].Err;
            d.appendChild(newdiv);
        }
        //d.style.visibility='visible';
    }
     this.propertiesCompleted  = function(result)
    {
        var grid = $('masterNoDataTemplate');
        
        var child = $('propertyGridTable');
        if(child!=null)
            grid.removeChild(child);
        //var tbody = $('masterItemTemplate');
        var mi=null;
        var table = document.createElement('table');
        table.id = 'propertyGridTable';
        table.className = 'tableborder';
        var tr = null;
        //delete rows
        var props  = result.props;
        for(var i=0;i<table.rows.length;i++)
            table.deleteRow(i);
        for(var i =0;i<props.length;i++)
        {
            tr = table.insertRow(-1);
            mi = props[i];
            var td = tr.insertCell(-1);
            td.innerText = mi.Name;
            var tb = document.createElement('input');
            tb.type  = 'text';
            tb.id = mi.Name;
            tb.value = mi.Value;
             tb.attachEvent('onblur',propertyChanged);
            td = tr.insertCell(-1);
            //td.innerText = mi.Value;
            td.appendChild(tb);
            
            
        }
        id = result.Id;
       //alert(table.innerHtml);
        grid.appendChild(table);
        grid.style.visibility='visible';
        changeTheImage(result.Id,result.UUID);
        
    }
    var id;
    function propertyChanged()
    {
         //debug.trace('property changed for ' + _propertyHotspot.Name);
         var el = $('propertyGridTable');
         var newprops = new Array(el.rows.length);
       
        for(var i =0;i<el.rows.length;i++)
        {
            newprops[i] = {Name:el.rows[i].cells[0].innerText,Value:el.rows[i].cells[1].firstChild.value};
            
        }
        //ARGH
        var callback = Sys.Application.findObject(id).get_behaviors()[0]['propertiesCompleted'];
        var callback2 = Sys.Application.findObject(id).get_behaviors()[0]['gotErrors'];
        WorkflowAtlasDesigner.ImageService.SetProperties(id,_propertyHotspot.Name,newprops,callback,OnTimeout);
        WorkflowAtlasDesigner.ImageService.GetValidationErrors(callback2,OnTimeout);
    }
     var _hotspot;
     var data;
     this.drop = function(dragMode, type, data) {
        
        var e = window.event;
        $('data').value = data.innerText;	
        //this has to change to make it work on Mozilla
	    this.control.element.click();
        this.dropped.invoke(this, Sys.EventArgs.Empty);


    }
    function changeTheImage(id,uuid)
    {
        var obj = Sys.Application.findObject(id).get_behaviors()[0];
        var url = obj.get_baseurl() + '?act=&type=&e=' + uuid;           
	    var el = $(id);
	    el.src = url;
    }
    function requestCompleted(rd){
            changeTheImage(rd.Id,rd.UUID)
     }
	var _act;
	this.cutActivity = function()
	{
	    var hotspot = _hotspot;
	    if(hotspot!=null)
	    {
	        _act = hotspot.Name;
	        WorkflowAtlasDesigner.ImageService.ImageOperation(this.control.element.id,"Cut",_act,_currentX,_currentY,requestCompleted,OnTimeout);
   
	    }
	}
    this.copyActivity = function()
    {
       
        var hotspot = _hotspot;
        if(hotspot!=null)
        {
            _act = hotspot.Name;
        }
        //_act = {TheAct: act,TheId: id};
    }
    this.pasteActivity = function()
    {
       
        WorkflowAtlasDesigner.ImageService.ImageOperation(this.control.element.id,"Paste",_act,_currentX,_currentY,requestCompleted,OnTimeout);
   
    }
    this.deleteActivity = function(act)
    {
        //debug.trace('deleting ' + act);
         WorkflowAtlasDesigner.ImageService.ImageOperation(this.control.element.id,"Delete",act,_currentX,_currentY,requestCompleted,OnTimeout);
  
    }
     this.canDrop = function(dragMode, dataType) {
        return dataType == 'HTML';
        
    }
    this.onDragEnterTarget = function(dragMode, type, data) {
    }
    this.onDragLeaveTarget = function(dragMode, type, data) {
      var e = window.event;
         //debug.trace('onDragLeaveTarget ' + e.offsetX + ' ' + e.offsetY );
     }
    this.onDragInTarget = function(dragMode, type, data) {
     }
     this.get_dropTargetElement = function() {
       
         return this.control.element;


    }
   this.imageLoad = function()
    {
       this.mouseover();//cause the hotspots to reload
    }
    var contextisvisible=0;
   
    this.changeImage = function(qs)
    {
          var url = _baseurl + '?' + qs;     
          this.control.element.src = url;
    }
   
     this.getDescriptor = function() {
     
        var td = Flanders.UI.Web.Atlas.DesignerImage.callBaseMethod(this, 'getDescriptor');      
        td.addMethod('showView',[ Sys.TypeDescriptor.createParameter('act', String),Sys.TypeDescriptor.createParameter('view', String)]);
        td.addMethod('changeImage');
        td.addMethod('cutActivity');
	    td.addMethod('copyActivity');
        td.addMethod('pasteActivity');
        td.addMethod('deleteActivity');
        td.addMethod('getProperties',[ Sys.TypeDescriptor.createParameter('act', String)]);
        td.addProperty('baseurl',Object, false, Sys.Attributes.Element, true);
        td.addProperty('x',Object, false, Sys.Attributes.Element, true);
        td.addProperty('y',Object, false, Sys.Attributes.Element, true);
        td.addEvent('dropped', true);
        td.addMethod('openWF_Click');
        td.addMethod('saveWF_Click');
        td.addMethod('newWF_Click');
        td.addMethod('openWFHover');
        td.addMethod('openWorkflowById',[ Sys.TypeDescriptor.createParameter('act', String)]);
        return td;
    }
    this.openWorkflowById = function(act)
    {
         _showingmenu=false;
        this.getMenu().hide();
        _currentWFId = act;
         WorkflowAtlasDesigner.ImageService.ChangeWorkflow(this.control.element.id,act,requestCompleted);
    }
    
    this.openWFHover  = function()
    {
        WorkflowAtlasDesigner.ImageService.GetWorkflows(this.control.element.id,gotWorkflows);
    }
    var workflowdata = null;
    function gotWorkflows(results)
    {
        workflowdata = results;
    }
    var _showingmenu = false;
    this.openWF_Click = function()
    {
        var e = window.event;
        if(_showingmenu)
            {
            _showingmenu = false;
             this.getMenu().hide();
             return;
            }
       
        _currentX = e.clientX+document.body.scrollLeft;
        _currentY = e.clientY+document.body.scrollTop;
       
      
        this.getMenu().clear();
  
        this.getMenu().dataBind(workflowdata);
        var p  ={x:_currentX , y: _currentY};
        this.getMenu().setLocation(p);
        this.getMenu().show();
        _showingmenu = true;
      
       
    }
   
    this.saveWF_Click = function()
    { 
        debug.trace('saving ' + _currentWFId);
        if(_currentWFId==_emptyGuid)//need a name
        {   debug.trace('saving new workflow');
            var name = Sys.UI.Window.inputBox('Enter a workflow name','');
            WorkflowAtlasDesigner.ImageService.SaveNewWorkflow(this.control.element.id,name,newWorkflow);
        }
        WorkflowAtlasDesigner.ImageService.SaveWorkflow(this.control.element.id,_currentWFId,requestCompleted);
    }
    
    function newWorkflow(result)
    {
        _currentWFId = result;//no need to change the image
    }
    this.newWF_Click = function()
    { 
         _currentWFId  = _emptyGuid;
        WorkflowAtlasDesigner.ImageService.NewWorkflow(this.control.element.id,requestCompleted);
    }
    var _emptyGuid = '{00000000-0000-0000-0000-000000000000}';
    var _currentWFId = _emptyGuid;
    var _x;
    var _y;
    this.get_x = function()
    {
        return _x;
    }
    this.set_x = function(value)
    {
        _x = value;
    }
     this.get_y = function()
    {
        return _y;
    }
    this.set_y = function(value)
    {
        _y = value;
    }
    var _baseurl;
     this.get_baseurl = function() {
        return _baseurl;
    }
    this.set_baseurl = function(value) {
        _baseurl = value;
    }
    function displaymenu()
    {
        var e = window.event;
      // debug.trace('scroll ' + document.body.scrollLeft + ' ' + document.body.scrollTop );
        el=document.getElementById("menu1");
        _currentX = e.clientX+document.body.scrollLeft;
        _currentY = e.clientY+document.body.scrollTop;//>e.offsetY?e.clientY:e.clientY+e.screenY+20;
        //remove children
        var child =null;
        el.innerHTML=""; 
        var hotspot = HitTest(e.offsetX ,e.offsetY);
        //add the elements
        contextisvisible=1;
        if(hotspot!=null)
        {
            _hotspot=hotspot;
            this.getMenu().dataBind(hotspot.ContextMenuItems);
            var p  ={x:_currentX , y: _currentY};
            Sys.UI.Control.setLocation(el,p);
            el.style.visibility="visible";
           
        }
        else
        {
            //main context menu - maybe this should be grabbed from the server?
            var mainmenu = new Array(1);
            mainmenu[0] ={Name: "Paste", Cmd:  {Name: 'pasteActivity',ObjRef: this.get_id(),Args: ['blank']}};
            var p  ={x:_currentX,y:_currentY};
            this.getMenu().dataBind(mainmenu);
             this.getMenu().setLocation(el,p);
             this.getMenu().show();
        }
             e.returnValue  = false;
            return false
      
    }
    this.getMenu  = function()
    {
        //HACK:
        return Sys.Application.findObject('menu1').get_behaviors()[0];
        
    }
    var _currentX;
    var _currentY;
    function OnTimeout(result) 
    {
         debug.trace("Timed out");
    }
    this.windowmousemove = function()
    {
        var e = window.event;
        this.set_x(e.offsetX);
        this.set_y(e.offsetY);
        var x = this.get_x();
        var y =this.get_y();
    }
    this.mousemove  = function()
    {
        var e = window.event;
        this.set_x(e.offsetX);
        this.set_y(e.offsetY);
        var x = this.get_x();
        var y =this.get_y();
       
        var hotspot = HitTest(e.offsetX,e.offsetY);
        if(hotspot!=null)
        {
           
            e.srcElement.title = hotspot.Name;
        }
        else
           e.srcElement.title = '';
    }
    var x;
    var y;
    this.mouseover  = function()
    {
          var e = window.event;
          WorkflowAtlasDesigner.ImageService.GetHotSpots(this.control.element.id,OnHSComplete,OnTimeout);
       
    }

    var hotspots;
    function OnHSComplete(result) 
    {  
        hotspots = result;
    }
    function HitTest(x,y)
    {
        var hotspot;
        if(hotspots!=null)
        {
          
            for(var i=0;i<hotspots.length;i++)
            {
                hotspot = hotspots[i];
                if(Contains(x,y,hotspot))
                {
                  return hotspot;
                }
            }
        }
        return null;
    }
   
    function Contains(x, y,hotspot)
    {
        var hit = false;
        
        if((x>=hotspot.Left)&&(x<hotspot.Right))
        {
            if((y>=hotspot.Top)&&(y<hotspot.Bottom))
                hit = true;
        }
        return hit;
    }

 

    

}
Flanders.UI.Web.Atlas.DesignerImage.registerClass('Flanders.UI.Web.Atlas.DesignerImage', Sys.UI.Behavior);
Sys.TypeDescriptor.addType('script', 'designerImage', Flanders.UI.Web.Atlas.DesignerImage);

//Flanders.UI.Web.Atlas.PropertyGrid = function()
//{
//Flanders.UI.Web.Atlas.PropertyGrid.initializeBase(this);
//this.initialize = function()
//{
//}

//}
//Flanders.UI.Web.Atlas.DesignerImage.registerClass('Flanders.UI.Web.Atlas.PropertyGrid', Sys.UI.Behavior);
//Sys.TypeDescriptor.addType('script', 'propertyGrid', Flanders.UI.Web.Atlas.PropertyGrid);

Flanders.UI.Web.Atlas.PopupMenu = function()
{
    Flanders.UI.Web.Atlas.PopupMenu.initializeBase(this);
    this.initialize = function() {
    
    Flanders.UI.Web.Atlas.PopupMenu.callBaseMethod(this,'initialize');
            var _mousemove  = Function.createDelegate(this,this.mouseout);
            var _mouseover = Function.createDelegate(this,this.mouseover);
            var _click = Function.createDelegate(this,this.click);
            var _keypress = Function.createDelegate(this,this.keypress);
            this.control.element.attachEvent("onkeypress",_keypress);
            this.control.element.attachEvent("onmouseout",_mousemove);
            this.control.element.attachEvent("onmouseover", _mouseover);
            this.control.element.attachEvent("onclick",_click);
            this.set_itemstyle("menuItem");
            this.set_hoveritemstyle("menuHoverItem");
    }
    this.keypress = function()
    {
        var e = window.event;
        if(e.keyCode==27)//ESC
        {
            this.hide();
        }
    }
    
    this.click = function()
    {
      
        var e = window.event;
      
        var mi = null;
        for(var i=0;i<_items.length;i++)
        {
            if(_items[i].Name.trim()==e.srcElement.innerText.trim())
                mi = _items[i];
        }
//        var mie  = e.srcElement.get_behaviors()[0];
//        if(mie!=null)
//            mi = mie.get_item();
        if(mi!=null)
        {

            this.invokeMethod(Sys.Application.findObject(mi.Cmd.ObjRef),mi.Cmd.Name,mi.Cmd.Args);
            this.hide();
         }
    }
    this.invokeMethod = function(obj,cmd,args)
    {
        if(obj!=null)
        {
            var td = Sys.TypeDescriptor.getTypeDescriptor(obj);
            if(td!=null)
            {
                var methodInfo = td._getMethods()[cmd];
                if(methodInfo!=null)
                {
                    var method = obj[methodInfo.name];
                    return method.apply(obj, args);
                }
            }
        }
    }
    this.mouseover = function()
    {
         var e = window.event;
         this.resetItems();
        if(_hoveritemstyle!=null)
        {
           e.srcElement.className=_hoveritemstyle;
        
            
        }
    }
    this.resetItems = function()
    {
        for(var i=0;i<this.control.element.children.length;i++)
        {
            this.control.element.children[i].className = _itemstyle;
        }
    }
    this.mouseout = function()
    {
        
      
       
    }
     var _itemstyle;
     this.get_itemstyle = function() {
        return _itemstyle;
    }
    this.set_itemstyle = function(value) {
        _itemstyle = value;
    }
       var _hoveritemstyle;
     this.get_hoveritemstyle = function() {
        return _hoveritemstyle;
    }
    this.set_hoveritemstyle = function(value) {
        _hoveritemstyle = value;
    }
    var _cmdobj;
    this.dataBind = function(items,cmdobj)
    {
                if(items!=null)
                {
                    _cmdobj = cmdobj;
                    _items = items;
                    var mi=null;
                    for(var i=0;i<items.length;i++)
                    {
                        mi = items[i];
                        var div = document.createElement('div');
                        div.innerText = mi.Name;
                        if(_itemstyle!=null)
                            div.className=_itemstyle;
                        var b = new Flanders.UI.Web.Atlas.MenuItem(div);
                        b.set_item(mi);
                        this.control.element.appendChild(div);
                    }
                }
    }
    var _items;
    this.show = function()
    {
        this.control.element.style.visibility="visible";
    }
    this.hide = function()
    {
        this.control.element.style.visibility="hidden";
    }
    this.clear = function()
    {
        this.control.element.innerHTML=""; 
    }
    this.setLocation = function(p)
    {
        Sys.UI.Control.setLocation(this.control.element,p);
    }
    this.getDescriptor = function() {
     
        var td = Flanders.UI.Web.Atlas.PopupMenu.callBaseMethod(this, 'getDescriptor');      
        td.addMethod('dataBind');
        td.addMethod('show');
        td.addMethod('hide');
        td.addMethod('clear');
        td.addProperty('itemstyle',Object, false, Sys.Attributes.Element, true);  
        td.addProperty('hoveritemstyle',Object, false, Sys.Attributes.Element, true);       
        return td;
    }
    
}
Flanders.UI.Web.Atlas.PopupMenu.registerClass('Flanders.UI.Web.Atlas.PopupMenu', Sys.UI.Behavior);
Sys.TypeDescriptor.addType('script', 'popupMenu', Flanders.UI.Web.Atlas.PopupMenu);

Flanders.UI.Web.Atlas.MenuItem = function()
{
    Flanders.UI.Web.Atlas.MenuItem.initializeBase(this);
    this.initialize = function() {
        Flanders.UI.Web.Atlas.MenuItem.callBaseMethod(this,'initialize');
        var _click = Function.createDelegate(this,this.click);
        var _mouseover  = Function.createDelegate(this,this.mouseover); 
        var _mousemove  = Function.createDelegate(this,mouseout);
        this.control.element.attachEvent("onclick", _click);
        this.control.element.attachEvent("onmouseover", _mouseover);
        this.control.element.attachEvent("onmouseout",_mousemove);
    }
    
    this.click = function()
    {
        //this seems to never get fired for some reason
    }
    this.mouseover = function()
    {
            //debug.trace('mouseover');
    }
    this.mouseout = function()
    {
        //debug.trace('mouseoout');
    }
    this.getDescriptor = function() {
     
        var td = Flanders.UI.Web.Atlas.MenuItem.callBaseMethod(this, 'getDescriptor');      
        td.addProperty('item',Object, false, Sys.Attributes.Element, true);  
        return td;
    }
      var _item;
     this.get_item = function() {
        return _item;
    }
    this.set_item = function(value) {
        _item = value;
    }
    
}
Flanders.UI.Web.Atlas.MenuItem.registerClass('Flanders.UI.Web.Atlas.MenuItem', Sys.UI.Behavior);
Sys.TypeDescriptor.addType('script', 'menuItem', Flanders.UI.Web.Atlas.MenuItem);

