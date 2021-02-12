

function toggleOpenFolder(ev) {

    let arrow = ev.nextElementSibling.children[0];
    let folderItems = ev.nextElementSibling.children[1];
    
    if (folderItems.classList.contains('box-open')) {
        //Close folder
        folderItems.classList.remove('box-open')
        arrow.classList.remove('arrow-visible')
    }
    else {
        //Open folder
        closeAllFolders();

        folderItems.classList.add('box-open')
        arrow.classList.add('arrow-visible')
    }
}

function closeAllFolders() {
    let openFolders = document.getElementsByClassName('box-open')
    let openArrows = document.getElementsByClassName('arrow-visible')

    //console.dir(openFolders)

    if (openFolders.length > 0) {

        //openFolders.forEach(folder => folder.classList.remove('box-open'));
        //openArrows.classList.remove('arrow-visible')
        for (var i = 0; i < openFolders.length; i++) {
            openFolders[i].classList.remove('box-open')
            openArrows[i].classList.remove('arrow-visible')
        }
    }
}
