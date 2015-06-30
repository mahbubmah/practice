$(document).ready(function () {
    $('.glList').click(function (event) { event.preventDefault(); $('.glProducts .item').addClass('list-group-item'); });
    $('.glGrid').click(function (event) { event.preventDefault(); $('.glProducts .item').removeClass('list-group-item'); $('.glProducts .item').addClass('grid-group-item'); });
});