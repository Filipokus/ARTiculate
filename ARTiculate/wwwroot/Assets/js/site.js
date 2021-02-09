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
    const urlAction2 = document.getElementById("link-to-live").getAttribute("onClick")
    console.log(urlAction2)
    dateLive.setAttribute("onClick", urlAction2);
}

//------ Carousel on exhibitions index page --------
function loadNewContent(arrowBtn) {

    let activeCarouselDiv = arrowBtn.parentNode.parentNode
    let straightDiv = activeCarouselDiv.parentNode;
    let childrenOfStraightDiv = straightDiv.getElementsByClassName('carousel-container');
    let numberOfChildren = childrenOfStraightDiv.length;

    for (let i = 0; i < numberOfChildren; i++) {
        if (activeCarouselDiv === childrenOfStraightDiv[i]) {
            var carouselDivNumber = i;
            break;
        }
    }

    if (arrowBtn.className === 'arrow-left-btn') {
        if (carouselDivNumber !== 0) {
            childrenOfStraightDiv[carouselDivNumber - 1].style.display = 'initial';
        }
        else {
            childrenOfStraightDiv[numberOfChildren - 1].style.display = 'initial';
        }
    }

    else {
        if (carouselDivNumber !== numberOfChildren-1) {
            childrenOfStraightDiv[carouselDivNumber + 1].style.display = 'initial';
        }
        else {
            childrenOfStraightDiv[0].style.display = 'initial';
        }

    }

    activeCarouselDiv.style.display = 'none';
}

