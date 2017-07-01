(function() {
    window.cms.handlebars = {
        render: function(tplid, data, container) {

            $(container).html(this.getHtml(tplid, data));
        },

        getHtml: function (tplid, data) {


            // Grab the template script
            var theTemplateScript = $(tplid).html();

            // Compile the template
            var theTemplate = Handlebars.compile(theTemplateScript);

            return theTemplate(data);
        }
    };
})();