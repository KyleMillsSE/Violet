/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/


module.exports = function (grunt) {



    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.loadNpmTasks('grunt-browserify');
    grunt.loadNpmTasks('grunt-vueify');


    grunt.initConfig({
        clean: ['wwwroot/dist'],
        browserify: {
            files: {
                dest: 'wwwroot/dist/module.js',
                src: ['app/**/*.vue', 'app/**/*.js']
            },
            options: {
                transform: ['vueify', 'babelify']//, 
            },
        },
        vueify: {
            components: {
                files: [
                    {
                        expand: true,
                        src: 'app/**/*.vue',
                        dest: 'dist/',
                        ext: '.vue.js'
                    }
                ]
            }
        },
        sass: {
            dist: {
                files: {
                    'web/assets/css/style.css': 'source/sass/style.scss'
                }
            }
        },
        watch: {
            app: {
                files: ["app/**/*"],
                tasks: ["browserify"],
                options: {
                    spawn: false,
                }
            },
            libs: {
                files: ["bower_components/**/*"],
                tasks: ["concat"]
            },
            css: {
                files: 'source/sass/*.scss',
                tasks: ['sass'],
                options: {
                    livereload: true,
                }
            }
        },
        concat: {
            options: {
                separator: ';',
            },
            dist: {
                src: [
                    'bower_components/jquery/dist/jquery.js',
                    'bower_components/uikit/js/uikit.js',
                    'bower_components/uikit/js/components/nestable.js',
                    'bower_components/humanize-plus/public/src/humanize.js',
                    'bower_components/hogan/web/builds/3.0.2/hogan-3.0.2.min.js'
                ],
                dest: 'web/assets/js/libs.js',

            }
        },

    });

    grunt.registerTask('build', ['clean', 'browserify']);
};



