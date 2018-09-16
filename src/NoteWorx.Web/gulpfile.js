
"use strict";

var gulp = require("gulp"),
   rimraf = require("rimraf"),
   concat = require("gulp-concat"),
   cssmin = require("gulp-cssmin"),
   uglify = require("gulp-uglify"),
   rename = require("gulp-rename"),
   sequence = require("gulp-sequence");

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

gulp.task("clean:js", function (cb) {
   rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
   rimraf(paths.concatCssDest, cb);
});

gulp.task("clean:libs", function (cb) {
   rimraf(paths.lib, cb);
});

gulp.task("clean", ["clean:js", "clean:css", "clean:libs"]);

gulp.task("min:js", function () {
   return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
      .pipe(concat(paths.concatJsDest))
      .pipe(uglify())
      .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
   return gulp.src([paths.css, "!" + paths.minCss])
      .pipe(concat(paths.concatCssDest))
      .pipe(cssmin())
      .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);

gulp.task("copy:fontawesomeCss", function () {
   return gulp
      .src(paths.nodemodules + "@fortawesome/fontawesome-free/css/all.min.css")
      .pipe(rename("./font-awesome.min.css"))
      .pipe(gulp.dest(paths.libCss));
});

gulp.task("copy:bootstrapCss", function () {
   return gulp
      .src(paths.nodemodules + "bootstrap/dist/css/bootstrap.min.css")
      .pipe(gulp.dest(paths.libCss));
});

gulp.task("copy:csslibs", ["copy:fontawesomeCss", "copy:bootstrapCss"]);

gulp.task("copy:jslibs", function () {
   return gulp
      .src([
         paths.nodemodules + "jquery/dist/jquery.min.js",
         paths.nodemodules + "jquery-validation/dist/jquery.validate.min.js",
         paths.nodemodules + "jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js",
         paths.nodemodules + "bootstrap/dist/js/bootstrap.min.js",
         paths.nodemodules + "popper.js/dist/popper.min.js"
      ])
      .pipe(gulp.dest(paths.libJs));
});

gulp.task("copy:fonts", function () {
   return gulp
      .src(paths.nodemodules + "@fortawesome/fontawesome-free/webfonts/**/*")
      .pipe(gulp.dest(paths.libWebfonts));
});

gulp.task("copy", ["copy:csslibs", "copy:jslibs", "copy:fonts"]);

gulp.task("build", sequence("clean", "min", "copy"));

gulp.task("default", ["build"]);