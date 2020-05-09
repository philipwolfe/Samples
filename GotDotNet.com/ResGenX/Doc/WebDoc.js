function Expose(levelID, imageID) {
	var level = levelID
	var image = imageID
	if (level.style.display == "block") {
		level.style.display = "none";
		image.src = "../Plus.jpg";	
	}else{
		level.style.display = "block";
		image.src = "../Minus.jpg";
	}
}

function ShowInfo(solutionID, imageID) {
	var sol = solutionID
	var image = imageID
	if (sol.style.display == "block") {
		sol.style.display = "none";
		image.src = "Plus.jpg";	
	}else{
		sol.style.display = "block";
		image.src = "Minus.jpg";
	}
}

