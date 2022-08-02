window.ShowAlert = function(title,message,alerttype){
    Swal.fire(title, message, alerttype);
};
window.ShowConfirm = function (title, message) {
    return new Promise(function (resolve) {
        Swal.fire({
            title: title,
            text:message,
            showDenyButton: true,
            confirmButtonText: 'Yes! Confirm',
            denyButtonText: `Don't Cancel it.`,
        }).then((result) => {
            /* Read more about isConfirmed, isDenied below */
            if (result.isConfirmed) {
                resolve(true);
            } else if (result.isDenied) {
                resolve(false);
            }
            else {
                resolve(false);
            }
        })
    });
}