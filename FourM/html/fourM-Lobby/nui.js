function displayNui(display) {
    if (display) { 
        $("html").hide(); 
    } else { 
        $("html").show(); 
    }
}

window.addEventListener('message', (event) => {
    if (event.data.type === 'display') {
        displayNui(event.data.display)
    }
});