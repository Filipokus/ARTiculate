

function toggleOpenFolder(ev) {

    let folder = ev.parentNode
    let arrow = folder.nextElementSibling.children[0]
    let folderItems = folder.nextElementSibling.children[1]

    if (folder.classList.contains('folder-open')) {
        //Close folder
        folder.classList.remove('folder-open')
        folderItems.classList.remove('box-open')
        arrow.classList.remove('arrow-visible')
    }
    else {
        //Open folder
        folder.classList.add('folder-open')
        folderItems.classList.add('box-open')
        arrow.classList.add('arrow-visible')
    }
}
