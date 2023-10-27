<template>
    <div>
        <div class="relative" style="padding-bottom: 56.25%;">
            <iframe :src="embedUrls[0]" frameborder="0" allowfullscreen class="absolute inset-0 w-full h-full"></iframe>
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
