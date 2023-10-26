<template>
    <div>
        <div>
            <iframe width="720" height="405" :src="embedUrls[0]" frameborder="0" allowfullscreen class="mr-2"></iframe>
        </div>
    </div>
</template>
  
<script>
export default {
    props: {
        videoSource: String
    },
    computed: {
        embedUrls() {
            if (this.videoSource) {
                return [`https://drive.google.com/file/d/${this.videoSource}/preview`];
            } else {
                return [];
            }
        }
    }
};
</script>
