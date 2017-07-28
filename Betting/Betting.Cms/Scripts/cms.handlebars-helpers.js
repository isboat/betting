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

    // Register a helper
    Handlebars.registerHelper('renderTeam',
        function (team) {
            // Grab the template script
            var theTemplateScript = $("#team-tpl").html();

            // Compile the template
            var theTemplate = Handlebars.compile(theTemplateScript);
            
            return theTemplate(team);
        });

    // Register a helper
    Handlebars.registerHelper('renderSelection',
        function (team) {
            // Grab the template script
            var theTemplateScript = $("#sel-tpl").html();

            // Compile the template
            var theTemplate = Handlebars.compile(theTemplateScript);
            
            return theTemplate(team);
        });

    // Register a helper
    Handlebars.registerHelper('renderSelectFields',
        function (opt) {
            // Grab the template script
            
            var theTemplateScript = "<select {{#if id}} id='{{id}}' {{/if}} {{#if disabled}} disabled='disabled' {{/if}} class='form-control text-box single-line{{#if cssclass}} {{cssclass}} {{/if}}'>" +
                "{{#each options}} " +
                "<option value='{{val}}' {{#if selected}}selected='selected'{{/if}}>{{text}}</option>" +
                "{{/each}}" +
                "</select>";

            // Compile the template
            var theTemplate = Handlebars.compile(theTemplateScript);
            
            return theTemplate(opt);
        });
})();