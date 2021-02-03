function viewImageCloseUp(ev) {
    let veil = document.getElementById("veil");
    let image = document.createElement("img");
    let imagebox = document.getElementById("imageCloseUp-container");
    image.src = ev.src;
    image.classList.add('shownImage');
    veil.classList.remove('veilHidden');
    veil.classList.add('veilShowing');
    imagebox.appendChild(image);
    console.log(imagebox);
}

function hideImageCloseUp() {
    let veil = document.getElementById("veil");
    let imagebox = document.getElementById("imageCloseUp-container");
    imagebox.removeChild(imagebox.childNodes[0]);
    veil.classList.remove('veilShowing');
    veil.classList.add('veilHidden');
}

