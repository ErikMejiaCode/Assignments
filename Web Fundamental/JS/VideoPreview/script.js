console.log("page loaded...");


document.querySelector(".videoplay").addEventListener("mouseover", function(){
    this.play()
})

document.querySelector(".videoplay").addEventListener("mouseout", function(){
    this.pause()
})
