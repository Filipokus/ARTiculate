
function artworkHoverIn(ev) {
    let btn = ev.parentNode
    let img = btn.firstChild.nextSibling
    img.style.boxShadow = '0vw 0vw 3vw 1vw rgb(223, 221, 228, 0.5)';
    btn.style.cursor = "pointer";
}

function artworkHoverOut(ev) {
    let btn = ev.parentNode
    let img = btn.firstChild.nextSibling
    img.style.boxShadow = '0 0 3vw 2vw #0c0c0c';
    btn.style.cursor = "default";
}