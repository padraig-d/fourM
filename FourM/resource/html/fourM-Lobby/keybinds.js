$(document).keydown(function(e){
    if (e.which == 13){
        $("#ready-button").click().addClass('button-active');
    }
});

$(document).keyup(function(e){
    if (e.which == 13){
        $("#ready-button").click().removeClass('button-active');
    }
});