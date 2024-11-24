function displayNui(display) {
    console.log(display)
    if (display) { 
        $("body").show(); 
    } else { 
        $("body").hide(); 
    }
}

window.addEventListener('message', (event) => {
    let data = event.data;

    if (data.type === 'display') {
        displayNui(event.data.display);
    } else if (data.action === 'setLocalPlayerName') {
        setLocalPlayerName(data.pName);
    } else if (data.action === 'updatePlayerList') {
        updatePlayerList(data.playerList);
    }
});