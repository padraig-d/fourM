function displayNui(display) {
    console.log(display)
    if (display) { 
        $("body").show(); 
    } else { 
        $("body").hide(); 
    }
}

window.addEventListener('message', (event) => {
    if (event.data.type === 'display') {
        displayNui(event.data.display);
    }
});