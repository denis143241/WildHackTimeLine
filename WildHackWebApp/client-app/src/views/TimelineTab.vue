<template>
  <div class="timeline-tab">
    <block-timeline />
  </div>
</template>

<script>
import blockTimeline from "../components/blockTimeline.vue";
export default {
  mounted() {
    if (this.$store.state.dataForTimeline.length === 0) {
      this.$store.dispatch("fetchTimeLineSomePart", this.$store.state.dataForTimeline.length);
    }
  },
  components: {
    blockTimeline,
  },
};
</script>

<style lang="less" scoped>
.timeline-tab {
  height: 100vh - 200px;
  overflow-y: hidden;
}
</style>

<style lang="less"></style>
