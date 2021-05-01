const { series, parallel, src, dest } = require('gulp');
const rimraf = require("rimraf");
const concat = require("gulp-concat");
const cssmin = require("gulp-cssmin");
const uglify = require("gulp-uglify");
const rename = require("gulp-rename");

//
// Configure Paths
//

var paths = {
    webroot: "./wwwroot/",
    nodemodules: "./node_modules/"
};

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";
paths.lib = paths.webroot + "lib/"
paths.libCss = paths.lib + "css";
paths.libJs = paths.lib + "js";
paths.libWebfonts = paths.lib + "webfonts";

//
// Define Private Clean Tasks
//

function cleanJs(cb) {
    rimraf(paths.concatJsDest, cb);
}

function cleanCss(cb) {
    rimraf(paths.concatCssDest, cb);
}

function cleanLibs(cb) {
    rimraf(paths.lib, cb);
}

//
// Define Private Minify Tasks
//

function minifyJs() {
    return src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(dest("."));
}

function minifyCss() {
    return src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(dest("."));
}

//
// Define Private Copy Tasks
//

function copyFontawesomeCss() {
    return src(paths.nodemodules + "@fortawesome/fontawesome-free/css/all.min.css")
        .pipe(rename("./font-awesome.min.css"))
        .pipe(dest(paths.libCss));
}

function copyBootstrapCss() {
    return src(paths.nodemodules + "bootstrap/dist/css/bootstrap.min.css")
        .pipe(dest(paths.libCss));
}

function copyJslibs() {
    return src([
            paths.nodemodules + "jquery/dist/jquery.min.js",
            paths.nodemodules + "jquery-validation/dist/jquery.validate.min.js",
            paths.nodemodules + "jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js",
            paths.nodemodules + "bootstrap/dist/js/bootstrap.min.js",
            paths.nodemodules + "popper.js/dist/popper.min.js"
        ])
        .pipe(dest(paths.libJs));
}

function copyFonts() {
    return src(paths.nodemodules + "@fortawesome/fontawesome-free/webfonts/**/*")
        .pipe(dest(paths.libWebfonts));
}

//
// Define Public Tasks
//

exports.clean = parallel(cleanCss, cleanJs, cleanLibs);
exports.minify = parallel(minifyCss, minifyJs);
exports.copy = parallel(copyBootstrapCss, copyFontawesomeCss, copyFonts, copyJslibs);
exports.default = series(
    parallel(cleanCss, cleanJs, cleanLibs),
    parallel(minifyCss, minifyJs),
    parallel(copyBootstrapCss, copyFontawesomeCss, copyFonts, copyJslibs));