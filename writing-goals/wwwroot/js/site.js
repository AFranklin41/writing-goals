// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var sweetTable = document.querySelectorAll('#sweet-table .editable');

sweetTable
    .forEach(e => e.onclick = function (e) {
        //const idToGet = event.target.id.split("-")[2]
        this.contentEditable = true;
        this.focus();
        //console.log(idToGet)
    })

//['keydown', 'mouseout', 'mouseleave'].forEach(function (e) {
//sweetTable.forEach(e => e.addEventListener)
//}

//function addListenerMulti(element, eventNames, listener) {
//    var events = eventNames.split(' ');
//    for (var i = 0, iLen = events.length; i < iLen; i++) {
//        element.addEventListener(events[i], listener, false);
//    }
//}


sweetTable.forEach(e => e.addEventListener("keydown", function (e) {
    //addListenerMulti(sweetTable.forEach(e => e, 'keydown mouseleave mouseout', function (e) {
    //const idToGet = event.target.id.split("-")[2]
    const textContent = e.target.textContent
    const boxToEdit = e.target.id.split("-")[1]

    var goal = {}

    if (e.key === 'Enter') {

        const idToGet = event.target.id.split("-")[2]
        console.log(idToGet)
        if (!e) {
            e = window.event;
        }
        if (e.preventDefault) {


            e.preventDefault();
            this.contentEditable = false;

            console.log(idToGet)

            goal.Id = idToGet
            if (boxToEdit.includes("time")) {
                goal.TimeActual = textContent
            } if (boxToEdit.includes("count")) {
                goal.WordCountActual = textContent
            } if (boxToEdit.includes("goal")) {
                goal.OptionalGoal = textContent
            };


            console.log(goal)

            fetch(`/Goals/Edit/${event.target.id.split("-")[2]}`, {
                method: 'POST',
                body: JSON.stringify(goal),
                headers: {
                    'Content-Type': 'application/json'
                }
            })
            //}).then(() => {
            //    window.location.reload(); // TODO: refactor 
            //})

        } else {
            e.returnValue = false;
        }
    };
}))


sweetTable.forEach(e => e.addEventListener("mouseout", function (e) {
    const textContent = e.target.textContent
    const boxToEdit = e.target.id.split("-")[1]

    var goal = {}

    const idToGet = event.target.id.split("-")[2]
    console.log(idToGet)
    if (!e) {
        e = window.event;
    }
    if (e.preventDefault) {


        e.preventDefault();
        this.contentEditable = false;

        console.log(idToGet)

        goal.Id = idToGet
        if (boxToEdit.includes("time")) {
            goal.TimeActual = textContent
        } if (boxToEdit.includes("count")) {
            goal.WordCountActual = textContent
        } if (boxToEdit.includes("goal")) {
            goal.OptionalGoal = textContent
        };


        console.log(goal)

        fetch(`/Goals/Edit/${event.target.id.split("-")[2]}`, {
            method: 'POST',
            body: JSON.stringify(goal),
            headers: {
                'Content-Type': 'application/json'
            }
        })
        //}).then(() => {
        //    window.location.reload(); // TODO: refactor 
        //})

    } else {
        e.returnValue = false;
    }
}
))

