using System.Web.Optimization;

namespace Enterprise_Resource_planning
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/smartadmin").Include(
                "~/Content/dropzone/dropzone.css",
                "~/Content/smartadmin-production.min.css",
                "~/Content/toastr.css",
                "~/Scripts/plugins/datatables/datatables.min.css",
                "~/Scripts/plugins/datatable-responsive/css/datatables.responsive.css",
                "~/Content/css/lockscreen.min.css",
                "~/Content/css/smartadmin-rtl.min.css",
                "~/Content/css/smartadmin-production-plugins.min.css",
                "~/Content/css/smartadmin-skins.min.css")
                .IncludeDirectory("~/Content/css", "font-awesome.min.css").Include(
                "~/Content/bootstrap/bootstrap.css"));

            bundles.Add(new StyleBundle("~/content/alertify").Include(
                "~/Content/alertify/alertify.css",
                "~/Content/alertify/themes/default.css"));

            bundles.Add(new StyleBundle("~/content/bootstrap-datepicker").Include(
                "~/Content/bootstrap-datepicker/css/default.css",
                "~/Content/bootstrap-datepicker/css/datepicker.css",
                "~/Content/bootstrap-datepicker/css/datepicker3.css"));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap-datepicker").Include(
                "~/Content/bootstrap-datepicker/js/bootstrap-datepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/dropzone").Include(
                "~/scripts/dropzone/dropzone.js").Include(
                "~/scripts/dropzone-amd-module.js"));

            bundles.Add(new ScriptBundle("~/Scripts/smartadmin").Include(
                "~/Scripts/app.config.js",
                "~/Scripts/plugins/jquery-touch/jquery.ui.touch-punch.min.js",
                "~/Scripts/bootstrap/bootstrap.min.js",
                "~/Scripts/notification/SmartNotification.min.js",
                "~/Scripts/smartwidgets/jarvis.widget.min.js",
                "~/Scripts/plugins/jquery-validate/jquery.validate.min.js",
                "~/Scripts/plugins/jquery-validate/jquery.validate.unobtrusive.min.js",
                "~/Scripts/plugins/masked-input/jquery.maskedinput.min.js",
                "~/Scripts/plugins/select2/select2.min.js",
                "~/Scripts/plugins/bootstrap-slider/bootstrap-slider.min.js",
                "~/Scripts/plugins/bootstrap-progressbar/bootstrap-progressbar.min.js",
                "~/Scripts/plugins/msie-fix/jquery.mb.browser.min.js",
                "~/Scripts/plugins/fastclick/fastclick.min.js",
                "~/Scripts/app.min.js",
                "~/Scripts/toastr.js"
                ).IncludeDirectory(
                "~/scripts/plugins/jquery-unobtrusive-ajax", "jquery.unobtrusive-*"));

            bundles.Add(new ScriptBundle("~/bundles/PartialJQueryVal").Include(
                "~/Scripts/plugins/jquery-validate/jquery.validate.min.js",
                "~/Scripts/plugins/jquery-validate/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/customJs").Include(
                 "~/Scripts/ERP.js"
                 ));

            bundles.Add(new ScriptBundle("~/Scripts/dropzonescripts").Include(
                     "~/Scripts/dropzone/dropzone.js"));

            bundles.Add(new ScriptBundle("~/Scripts/appJs").Include(
                     "~/Scripts/app/orderJs.js"));

            bundles.Add(new ScriptBundle("~/Scripts/datatables").Include(
                "~/Scripts/plugins/datatables/datatables.min.js",
                "~/Scripts/plugins/datatable-responsive/js/datatables.responsive.js"
             ));

            bundles.Add(new ScriptBundle("~/bundles/jq-grid").Include(
                "~/Scripts/plugins/jqgrid/grid.locale-en.min.js",
                "~/Scripts/plugins/jqgrid/jquery.jqGrid.min.js"));

            bundles.Add(new ScriptBundle("~/Scripts/forms").Include(
                "~/Scripts/plugin/jquery-form/jquery-form.min.js"
                ));
            //BundleTable.EnableOptimizations = true;
        }
    }
}
