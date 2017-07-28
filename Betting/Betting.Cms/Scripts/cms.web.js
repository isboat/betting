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

        },
        get: function(options) {

            $.ajax({
                url: options.url,
                method: "GET",
                data: options.data,
                success: options.success,
                error: options.error
            });

        }
    };
})();