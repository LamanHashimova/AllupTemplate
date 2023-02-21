$(document).ready(function () {
    $('.productModal').click(function (e) {
        e.preventDefault();

        let url = $(this).attr('href');

        fetch(url)
            .then(res => {
                return res.json()
            })
            .then(data => {
                console.log(data);
            }}
    })
})