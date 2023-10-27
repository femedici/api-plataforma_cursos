<template>
    <div>
        <div>
            <iframe width="760" height="425" :src="embedUrls[0]" frameborder="0" allowfullscreen class="mr-2"></iframe>
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
