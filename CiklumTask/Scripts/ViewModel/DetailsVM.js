
var viewModel = new AjaxModelLoading("@Url.Action("AjaxModelLoading")");
ko.applyBindings(viewModel);

viewModel.getRandomModel();