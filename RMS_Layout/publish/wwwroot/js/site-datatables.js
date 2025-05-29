

<script>
    $(document).ready(function () {
        $('.datatable').DataTable({
            "pageLength": 10,
            "lengthChange": true,     // Allow user to change page size
            "searching": true,        // Enable search box
            "ordering": true,         // Enable column sorting
            "info": true,             // Show info text
            "autoWidth": false,       // Disable auto column width
            "responsive": true,       // Enable responsiveness
            "language": {
                "search": "Search:",
                "lengthMenu": "Show _MENU_ entries",
                "zeroRecords": "No matching records found",
                "info": "Showing _START_ to _END_ of _TOTAL_ entries",
                "infoEmpty": "No entries to show",
                "paginate": {
                    "first": "First",
                    "last": "Last",
                    "next": "Next",
                    "previous": "Previous"
                }
            }
        });
    });
</script>
