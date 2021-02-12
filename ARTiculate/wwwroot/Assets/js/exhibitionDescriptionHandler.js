
const fulldescription = document.querySelector('#description').textContent
let shortdescription = truncate(fulldescription, 111)

if (fulldescription.length > 111) {
    document.getElementById('description').textContent = shortdescription
}

function truncate(str, n) {
    return (str.length > n) ? str.substr(0, n - 1) + '...' : str;
};

