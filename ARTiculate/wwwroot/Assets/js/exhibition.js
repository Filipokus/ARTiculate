function viewImageCloseUp(ev) {
    //skapar kopia av bilden
    let image = document.createElement("img");
    image.src = ev.src;

    let veil = document.getElementById("veil");
    let imagebox = document.getElementById("imageCloseUp-container");
    let artInfo = document.getElementById("artworkInfo");

    //lägger in bilden i veil
    image.classList.add('shownImage');
    imagebox.prepend(image);

    //skapar stäng-knapp
    let close = document.createElement("img");
    close.src = "/Assets/Images/close.png";
    close.setAttribute("onclick", "hideImageCloseUp();");
    close.classList.add('close');
    imagebox.prepend(close);

    //Visar veil
    veil.classList.remove('veilHidden');
    veil.classList.add('veilShowing');

    //Visar info
    artInfo.classList.remove('hideInfo');
    artInfo.classList.add('showInfo');
}

function hideImageCloseUp() {
    let veil = document.getElementById("veil");
    let imagebox = document.getElementById("imageCloseUp-container");
    let artInfo = document.getElementById("artworkInfo");

    //Tar bort bilden
    imagebox.removeChild(imagebox.childNodes[0]);
    imagebox.removeChild(imagebox.childNodes[0]);

    //Gömmer veil
    veil.classList.remove('veilShowing');
    veil.classList.add('veilHidden');

    //Gömmer Info
    artInfo.classList.remove('showInfo');
    artInfo.classList.add('hideInfo');
}

