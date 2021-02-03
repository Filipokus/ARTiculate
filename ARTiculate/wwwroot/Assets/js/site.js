//-------General--------

//--------Menu---------
function hideOrShowMenu() {
    let menuOptions = document.getElementById('menu');
    if (menuOptions.style.display !== 'block') {
        menuOptions.style.display = 'block';
        menuOptions.style.animation = 'slide - down .3s ease - out';
    }
    else {
        menuOptions.style.display = 'none';
    }
}

function menuHoverIn(node) {
    let link = node;
    if (link.tagName !== 'A') {
        link = node.firstChild.nextSibling
    }
    link.style.color = '#F89A1E';
}

function menuHoverOut(node) {
    let link = node;
    if (link.tagName !== 'A') {
        link = node.firstChild.nextSibling
    }
    link.style.color = '#DFDDE4';
}

//---------Vernissages Overview page-----------

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


//---------About Vernissage when live------

function makeVernissageLive(node) {
    let dateLive = node;
    dateLive.style.backgroundColor = '#D5005E';
    let dateText = document.getElementById('live-date');
    dateText.style.color = '#DFDDE4';
    dateText.innerHTML = 'LIVE NOW 🠮';
    let liveImg = document.getElementById('live-btn-img');
    liveImg.style.visibility = 'visible';


}



