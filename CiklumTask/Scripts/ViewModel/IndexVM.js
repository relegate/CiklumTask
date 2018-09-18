var urlPath = window.location.pathname;

$(function () {
    ko.applyBindings(indexVM);
    indexVM.loadItems();
});

var indexVM = {
    Items: ko.observableArray([]),

    loadItems: function () {
        var self = this;
        $.ajax({
            type: "GET",
            url: urlPath + '/FillIndex',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                self.Items(data); 
            },
            error: function (err) {
                alert(err.status + " : " + err.statusText);
            }
        });
    }
};

function Items(Items) {
    this.Id = ko.observable(Items.Id);
    this.Name = ko.observable(Items.Name);
    this.Currency = ko.observable(Items.Currency);
    this.Price = ko.observable(Items.Price);
    this.Model = ko.observable(Items.Model);
    this.Color = ko.observable(Items.Color);
    this.Brand = ko.observable(Items.Brand);
    this.Image = ko.observable(Items.FrontImage);
}

