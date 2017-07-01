(function() {
    window.cms.web = {
        post: function(options) {

            $.ajax({
                url: options.url,
                method: "POST",
                data: options.data,
                success: options.success,
                error: options.error
            });

        }
    };
})();