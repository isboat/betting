(function() {

    // Register a helper
    Handlebars.registerHelper('renderCatItem',
        function (catItem) {
            // Grab the template script
            var theTemplateScript = $("#cat-item-tpl").html();

            // Compile the template
            var theTemplate = Handlebars.compile(theTemplateScript);

            return theTemplate(catItem);
        });

    // Register a helper
    Handlebars.registerHelper('renderContextItem',
        function (contextItem) {
            // Grab the template script
            var theTemplateScript = $("#context-item-tpl").html();

            // Compile the template
            var theTemplate = Handlebars.compile(theTemplateScript);

            return theTemplate(contextItem);
        });
})();