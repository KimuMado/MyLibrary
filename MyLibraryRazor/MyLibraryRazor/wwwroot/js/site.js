// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
let selectList = document.getElementById("Book_PublisherId");
//let publisherListOrg = selectList.options;
let pubInputBox = document.getElementById("PublisherInputStr");

function OnInputPublisher() {
    console.log("よびだされました");
    if (selectList != null) {
        if (pubInputBox != null) {
            for (let i = 0; i < selectList.options.length; i++) {
                if (selectList.options[i].label.indexOf(pubInputBox.value) == -1) {
                    selectList.options[i].setAttribute("hidden", true);
                } else {
                    selectList.options[i].removeAttribute("hidden");
                }
            }
        }
    }
}