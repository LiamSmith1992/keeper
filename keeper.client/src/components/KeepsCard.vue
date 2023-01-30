<template>
  <div class="component">
    <div class="card img-fluid " :key="keeps" :style="`background-image: url( ${keeps.img} )`">
      <div class="">

        {{ keeps.name }}
        <div class="text-end p-2">

          <img class="rounded-pill profile-img" :title="keeps.creator.name" :src="keeps.creator.picture" alt="">
        </div>
      </div>



    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';


export default {
  props: { keeps: { type: Object, required: true } },
  setup() {
    return {}
  }
};
</script>


<style lang="scss" scoped>
.profile-img {
  height: 60px;
  width: 60px;
}
</style>
