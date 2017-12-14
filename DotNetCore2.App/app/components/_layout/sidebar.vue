<template>
    <!--<aside class="sidebar">
        <ul class="list-unstyled">
            <li class="active">
                <a> <i class="fa fa-home" aria-hidden="true"></i>Home</a>
            </li>
            <li class="active">
                <a> <i class="fa fa-home" aria-hidden="true"></i>Side bar nav</a>
            </li>
            <li class="active">
                <a> <i class="fa fa-home" aria-hidden="true"></i>Side bar nav</a>
            </li>
        </ul>
    </aside>-->

</template>

<script>
    export default {
        name: 'sidebar'
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .sidebar {
        padding-top: 75px;
        background-color: #0082c8;
        width: 160px;
    }

    ul {
        list-style-type: none;
    }

    li {
        padding-left: 15px;
        padding-top: 10px;
        padding-bottom: 10px;
        display: inline-block;
    }

        li:active > a {
            color: #e7ae64;
        }

        li > a {
            font-size: 16px;
            color: #ffffff;
        }


    a:hover {
        cursor: pointer;
        color: #e7ae64;
        text-decoration: none;
    }

    a > i {
        padding-right: 10px;
    }

    .caret {
        width: 0;
        height: 0;
        border-top: 12px solid transparent;
        border-bottom: 12px solid transparent;
        border-right: 12px solid #e7ae64;
    }

    /*.caret {
        display: inline-block;
        width: 0;
        height: 0;
        margin-left: 2px;
        vertical-align: middle;
        border-top: 4px solid;
        border-right: 4px solid transparent;
        border-left: 4px solid transparent;
    }*/
</style> 