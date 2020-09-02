$(document).ready(function () {
    $('.btn-update').on('click', function (e) {
        var data = {
            id: $(e.target).data('id')
        };

        $.getJSON("/Umbraco/Api/Youtube/GetVideos", data, function (data) {
            $('.videos-list').empty();
            $.each(data.items, function (i, obj) {
                $('.videos-list').append(
                    `
                    <li>
                        <a href="https://www.youtube.com/watch?v=${obj.snippet.resourceId.videoId}">
                            <h2>${obj.snippet.title}</h2>
                            <img src="${obj.snippet.thumbnails.default.url}" />
                        </a>
                    </li>
                    `
                );

            });
        });


        console.log('log');
        e.preventDefault();
    });
})