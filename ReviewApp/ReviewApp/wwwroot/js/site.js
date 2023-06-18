const divForStars = document.querySelector(".placeForStars")
const rating = document.querySelector('#rating')
let starsList = []
function start(){
    for(let i = 0; i < 5; i++){
        var spanElement = document.createElement("span")
        spanElement.textContent = "⭐"
        spanElement.classList.add('star')
        spanElement.classList.add('star-not-used')
        divForStars.appendChild(spanElement)
        starsList.push(spanElement)
    }
    starsList.forEach(function (e, index){
        e.setAttribute('i', index)
    })
    rating.value = null
    starsList.forEach(e => e.addEventListener('click', onClick))
}

function onClick(){
    console.log(777)
    let b = this.getAttribute('i')
    let raitingValue = parseInt(b) + 1
    rating.value = raitingValue
    for(let i = 0; i < starsList.length; i++){
        if(i <= b){
            console.log(rating.value)
            starsList[i].classList.remove('star-not-used')
            starsList[i].classList.add('star-used')
        }
        else{
            starsList[i].classList.remove('star-used')
            starsList[i].classList.add('star-not-used')
        }
    }
}

start()