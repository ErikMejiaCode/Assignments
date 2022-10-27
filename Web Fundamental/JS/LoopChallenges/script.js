//challenge 1

var oddValues="";

for (var i=1; i<=20; i++) {
    if (i%2 !== 0) {
        console.log(i);
    }
} 

//challenge 2

var decrease = '';
for (i=100; i>=1; i--) {
    if (i%3 === 0) {
        console.log(i);
    }
}

//challenge 3

var arr =[4,2.5,1,-0.5,-2,-3.5]
for (i=0; i<arr.length; i++) {
    console.log(arr[i])
}

//challenge 4

var sum = 0;
for (var i=1; i<=100; i++){
    console.log(i + "+")
    sum = sum + i;
}
console.log(sum)

//challeng 5

var product = 1;
for (var i=1; i<=12; i++){
    console.log(i + "*")
    product = product * i;
}
console.log(product)