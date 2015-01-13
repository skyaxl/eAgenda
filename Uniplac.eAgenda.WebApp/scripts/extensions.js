String.format = function () {
    // The string containing the format items (e.g. "{0}")
    // will and always has to be the first argument.
    var theString = arguments[0];

    // start with the second argument (i = 1)
    for (var i = 1; i < arguments.length; i++) {
        // "gm" = RegEx options for Global search (more than one instance)
        // and for Multiline search
        var regEx = new RegExp("\\{" + (i - 1) + "\\}", "gm");
        theString = theString.replace(regEx, arguments[i]);
    }

    return theString;
};
Array.prototype.removeElement = function (element) {
    var index = this.indexOf(element);
    this.splice(index, 1);
}

Array.prototype.clear = function () {
    this.splice(0, this.length);
}

Array.prototype.pushArray = function () {
    for (var i = 0; i < arguments.length; i++) {
        var array = arguments[i];
        for (var j = 0; j < array.length; j++) {
            this.push(array[j]);
        }


    }

};