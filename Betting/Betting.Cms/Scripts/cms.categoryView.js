(function() {
    'use strict';

    function renderNewContext(data) {
        var html = window.cms.handlebars.getHtml("#context-item-tpl", data);

        $(".contexttable").append(html);
    }

    function renderContexts() {
        var list = [];

        $(".contexts li").each(function () {
            list.push({
                label: $(this).data("label"),
                id: $(this).data("id")
            });
        });

        window.cms.handlebars.render("#contexts-tpl", { contexts: list }, ".contextlist");

        window.cms.categoryview.contextlist = list;
    }

    function addNewContext() {
        var newLabel = $("#newLabel").val();
        if (!newLabel) {
            return;
        }

        var self = this;

        window.cms.web.post({
            url: "/trading/AddContext",
            data: { Label: newLabel, CatId: window.cms.categoryview.catid },
            success: function(data) {
                renderNewContext(data);
            }
        });
    }

    window.cms.categoryview = {
        addNewContext: addNewContext,
        renderContexts: renderContexts
    };
})();