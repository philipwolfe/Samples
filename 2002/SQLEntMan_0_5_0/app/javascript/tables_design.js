

	function SetFields (item, setFields) {
	
		
		ctlName = item.name.split("ctl");
		
		ctlName = ctlName[1].split(":");
		
		itemNumber = ctlName[0];
		
		typeStr = item.options[item.selectedIndex].text; 
		
		e = document.forms("editForm").elements;
	
		
	
		if (setFields==1) {
				setValues = true;
	
		} else {
				if (e("Repeater1:_ctl" + itemNumber + ":Name").value=='') {
					setValues = true;
				} else {
					setValues = false;
				}
		}
		
		if (setValues) {
			e("Repeater1:_ctl" + itemNumber + ":DefaultValue").value= "";
			e("Repeater1:_ctl" + itemNumber + ":DefaultValue").className= "TableInput";
			e("Repeater1:_ctl" + itemNumber + ":DefaultValue").disabled = false;
		}
		
		switch (typeStr.toLowerCase()) {
			//case "bigint":
					
					//e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Length").disabled = true;
					
					//e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					//e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					//e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = false;
					
					//e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInput";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = false;
					
					//e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInput";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = false;
					
					
					//if (setValues) {
					//	e("Repeater1:_ctl" + itemNumber + ":Length").value= 8;
					//	e("Repeater1:_ctl" + itemNumber + ":Precision").value= 19;
					//	e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
					//	e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
					//	e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
					//	e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					//}
					//break;	
					
			case "binary":
					
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInput";
					e("Repeater1:_ctl" + itemNumber + ":Length").disabled = false;
				
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";	
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					//e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
						
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 50;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
					break;	
			
			case "bit":
					
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Length").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 1;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
					break;		
			
			case "char":
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInput";
					e("Repeater1:_ctl" + itemNumber + ":Length").disabled = false;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 10;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
					break;	
					
			case "datetime":
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Length").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 8;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
					
					break;		
					
					
			 case "decimal":
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Length").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInput";
					e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = false;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInput";
					e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = false;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 9;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 18;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
						
					break;		
					
			 case "float":
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Length").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 8;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 53;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
					
					break;				
					
			 case "image":
			 
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Length").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 16;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
					
					break;				
		
			 case "int":
					
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Length").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = false;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInput";
					e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = false;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInput";
					e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = false;
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 4;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 10;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
					
					break;
					
					
			case "money":
					
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Length").disabled = true;
					
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
				
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
				
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
				
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					
					if (setValues) {			
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 8;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 19;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 4;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
					
					break;								
		
			 case "nchar":
					
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInput";
					e("Repeater1:_ctl" + itemNumber + ":Length").disabled = false;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 10;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
					
					
					break;	
			
			case "ntext":
			 
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Length").disabled = true;
				
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
						
				
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
				
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 16;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
						
					break;				
					
			case "numeric":
					
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Length").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInput";
					e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = false;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInput";
					e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = false;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = false;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInput";
					e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = false;
					
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInput";
					e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = false;
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 9;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 18;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
					
					
					break;			
					
			
			case "nvarchar":
			 
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInput";
					e("Repeater1:_ctl" + itemNumber + ":Length").disabled = false;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 50;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
					
					break;				
					
			case "real":
			 
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Length").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 4;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 24;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
					
					break;				
					
			case "smalldatetime":
			 
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInputOff";
					e("Repeater1:_ctl" + itemNumber + ":Length").disabled = false;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 4;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
					
					break;			
					
					
			case "smallint":
			 
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Length").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = false;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInput";
					e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = false;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInput";
					e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = false;
					
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 2;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 5;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
					
					break;					
		
			case "smallmoney":
			 
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Length").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 4;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 10;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 4;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
					
					break;					
		
		case "text":
			 
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Length").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 16;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
					
					break;				
		
		
		case "timestamp":
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Length").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":DefaultValue").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":DefaultValue").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 8;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}	
					
					
					break;				
		
		case "tinyint":
			 
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Length").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = false;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInput";
					e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = false;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInput";
					e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = false;
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 1;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 3;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}	
					
					break;		
					
		case "uniqueidentifier":
			 
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Length").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					if (setValues) {
				 		e("Repeater1:_ctl" + itemNumber + ":DefaultValue").value= "(newid())";			 
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 16;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
					
					break;		
					
					
		case "varbinary":
					
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInput";
					e("Repeater1:_ctl" + itemNumber + ":Length").disabled = false;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					if (setValues) {
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 50;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}	
					
					break;	
					
		
			case "varchar":
					e("Repeater1:_ctl" + itemNumber + ":Length").className= "TableInput";
					e("Repeater1:_ctl" + itemNumber + ":Length").disabled = false;
					
					e("Repeater1:_ctl" + itemNumber + ":Precision").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Precision").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Scale").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Scale").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Identity").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Seed").className= "TableInputOff";
					//e("Repeater1:_ctl" + itemNumber + ":Seed").disabled = true;
					
					e("Repeater1:_ctl" + itemNumber + ":Increment").className= "TableInputOff";
					e("Repeater1:_ctl" + itemNumber + ":Increment").disabled = true;
					
					if (setValues) {	
						e("Repeater1:_ctl" + itemNumber + ":Length").value= 50;
						e("Repeater1:_ctl" + itemNumber + ":Precision").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Scale").value= 0;
						e("Repeater1:_ctl" + itemNumber + ":Identity").checked = false;
						e("Repeater1:_ctl" + itemNumber + ":Seed").value= "";
						e("Repeater1:_ctl" + itemNumber + ":Increment").value= "";
					}
						
					break;	
										
		
		}
	  
		
	}

