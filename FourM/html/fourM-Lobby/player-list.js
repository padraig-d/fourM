function setLocalPlayerName(pName) {
    if (pName == null) return;
    
    var localPlayerElement = document.getElementById("local-player-name");
    localPlayerElement.textContent = pName;
}