window.global = {
    openModal: function (modalId) {
        modalId = '#' + modalId;
        $(modalId).modal('show');
    },
    closeModal: function (modalId) {
        modalId = '#' + modalId;
        $(modalId).modal('hide');
    },
}
// hide table details
$('.table .accordian-body').on('show.bs.collapse', function () {
    $(this).closest("table")
        .find(".collapse.in")
        .not(this)
        .collapse('toggle')
})