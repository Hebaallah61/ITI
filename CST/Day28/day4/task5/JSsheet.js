var name = prompt("Enter your name");
document.getElementById("n").innerText = name;


var duration = 1000; //*? m seconds

var blocksdiv = document.querySelector(".memeory-images");

var blocks = Array.from(blocksdiv.children);

//*console.log(blocks);

//*! extract operator if it is delgated it will be itrator 
var orderrang = [...Array(blocks.length).keys()];

//*? same result in a different way
//*var orderrang = Array.from(Array(blocks.length).keys());
//?console.log("b" + orderrang);
shuffle(orderrang);
//?console.log("a" + orderrang);


blocks.forEach((block, index) => {
    //*?console.log(index);
    block.style.order = orderrang[index];
    block.addEventListener('click', function () {
        flipblock(block);
    })
});

//? shuffle function

function shuffle(array) {
    var current = array.length, temp, random;
    while (current > 0) {
        //*random number
        random = Math.floor(Math.random() * current);

        current--;
        //?console.log(random);
        temp = array[current];
        array[current] = array[random];
        array[random] = temp;
    }
    return array;

}

//?swaping in new array
/**
  *TODO [1] save current element in temp
  *TODO [2] current element =random element
  *TODO [3] random element= get element from temp
  
  */


function flipblock(selectedBlock) {
    selectedBlock.classList.add('is-flipped');
    //?collect only two and check
    var allflipped = blocks.filter(flippedb => flippedb.classList.contains('is-flipped'));
    if (allflipped.length === 2) {//?if two only selected
        //?do not flipp the others
        /**
         * TODO 1-pointer vent  
        */
        stopclick();
        //?check if matched or not

        checkmatch(allflipped[0], allflipped[1]);

    }


}



function stopclick() {
    blocksdiv.classList.add('no-clicking');

    setTimeout(() => {
        //?remove no clicking 
        blocksdiv.classList.remove('no-clicking');
    }, duration); //?after 1sec you can able to click

}


function checkmatch(firstblock, secondblock) {
    var trieselement = document.querySelector('.tries span');
    var wonelement = document.querySelector('.won span');

    if (firstblock.dataset.technology === secondblock.dataset.technology) {
        firstblock.classList.remove('is-flipped');
        secondblock.classList.remove('is-flipped');

        //?to remove confision has match has the same characteristics of is flipped
        firstblock.classList.add('is-match');
        secondblock.classList.add('is-match');
        wonelement.innerHTML = Number(wonelement.innerHTML) + 1;
        //?console.log(Number(wonelement.innerHTML))


    }
    else {
        trieselement.innerHTML = Number(trieselement.innerHTML) + 1;
        setTimeout(() => {
            firstblock.classList.remove('is-flipped');
            secondblock.classList.remove('is-flipped');
        }, duration);

    }
    if (Number(wonelement.innerHTML) === 6) {
        console.log("iam" + Number(wonelement.innerHTML))
        alert("congratulations!");
    }

}







