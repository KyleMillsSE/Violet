///*
//This file in the main entry point for defining grunt tasks and using grunt plugins.
//Click here to learn more. https://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
//*/


module.exports = function (grunt) {

    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.loadNpmTasks('grunt-browserify');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-copy');

    grunt.initConfig({
        clean: {
            dist: {
                src: ['wwwroot/']
            }
        },
        //concat: {
        //    css: {
        //        src: [
        //            'app/css/app.css',
        //            'app/css/app-theme.css',
        //            'app/css/zapp.css'
        //        ],
        //        dest: 'wwwroot/dist/app.css',
        //    },
        //},
        browserify: {
            dist: {
                options: {
                    transform: ['vueify', 'babelify']
                },
                dest: 'wwwroot/dist/app.js',
                src: [
                    'app/**/*.js',
                    'app/**/*.vue'

                ]
            }
        },
        cssmin: {
            options: {
                shorthandCompacting: false,
                roundingPrecision: -1
            },
            combine: {
                files: {
                    'wwwroot/dist/app.min.css': ['app/css/*.css']// ['wwwroot/dist/app.css']
                }
            }
        },
        copy: {
            dist: {
                files: [
                    { expand: true, flatten: true , src: ['app/assets/favicon.ico'], dest: 'wwwroot/', filter: 'isFile' },
                ],
            },
        },
        watch: {
            app: {
                files: ["app/**/*"],
                tasks: ["browserify", "cssmin"],
                options: {
                    spawn: false,
                }
            },
        }
    });

    grunt.registerTask('build', [
        'clean',
        // 'concat',
        'browserify',
        'cssmin',
        'copy',
        'watch'
    ]);

    grunt.registerTask('default', ['build']);

};


