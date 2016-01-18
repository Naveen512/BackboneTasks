var SampleExample = SampleExample || {};

(function (SampleExample) {
    var Collections = {};

    Collections.DDLCollections = Backbone.Collection.extend({
        initialize: function() {

        },
        url: "http://localhost:2678/api/ContryState/GetDropDownValues"
     });

    SampleExample.Collections = Collections;
})(SampleExample)