/// <reference path="C:\DotNet Practise\BackboneExamples\BackboneSampe\BackboneView\Templates/DDLTemplate.html" />
/// <reference path="C:\DotNet Practise\BackboneExamples\BackboneSampe\BackboneView\Templates/DDLTemplate.html" />
var SampleExample = SampleExample || {};

(function (SampleExample) {

    var Views = {}
    var tempval={}
    Views.DDLViews = Backbone.View.extend({
        el: 'body',
        events: {
            'change #CountryName': 'ddlCountrychange',
            'change #StateName': 'ddlStateChange'
        },
        initialize: function () {
            this.collections = new SampleExample.Collections.DDLCollections();
            this.LoadDDLTelmplate();
            this.ddlLoad();
            

        },
        LoadDDLTelmplate: function () {
            $.get(location.origin + "/Templates/DDLTemplate.html", function (data) {
                $("#DDLHolder").append(data);
            });
        },
        ddlLoad: function () {
            var ddlCuntryName
            var serviceParam = {
                cID: !$("#CountryName :selected").val() ? -1 : parseInt($("#CountryName :selected").val()),
                sID: !$("#StateName :selected").val() ? -1 : parseInt($("#StateName :selected").val())
            };

            this.collections.fetch({
                data: serviceParam,
                'success': function (data) {
                   
                    var source = $("#DDLHandleBar").html();
                    var template = Handlebars.compile(source);
                    tempval = data.toJSON()[0].stateList;
                    var html = template({
                        CollectionCountry: data.toJSON()[0].countryList,
                        CollectionState: data.toJSON()[0].stateList

                    });
                    $("#jee").empty();
                    $("#jee").append(html);
                    $("#CountryName option[value='" + data.toJSON()[0].activeCID + "']").attr("selected", true);
                    //$("#StateName option[value='" + data.toJSON()[0].activeSID + "']").attr("selected", true);
                    //});
                    $("#StateDescriptiton").html('');
                },
                'error': function () {
                    console.log();
                }
            });
        },
        ddlCountrychange: function () {
            this.ddlLoad();
        },
        ddlStateChange: function () {
            var stateValue = Number($("#StateName").val())
            if (stateValue > 0) {
                $.each(tempval, function (key, val) {
                    if (val.StateID === stateValue) {
                        $("#StateDescriptiton").html("<h4>About Us:</h4><br>" + val.Descriptions);
                        if (val.ImageName)
                        {
                            $("#Images").attr('src', window.location.origin + '/Images/' + val.ImageName+'.jpg');
                        }
                       
                    }
                });
            }
            else {
                $("#StateDescriptiton").html('');
            }

        }


    });

    SampleExample.Views = Views.DDLViews;
    new Views.DDLViews();
})(SampleExample);

