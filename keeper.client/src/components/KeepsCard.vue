<template>

  <div v-if="keeps" class=" masonry">
    <div class="  p-2  ">
      <div class="card  box " :key="keeps" :style="`background-image: url( ${keeps.img} )`">

        <div class="d-flex justify-content-around align-items-end ">
          <div @click="setActiveKeep(keeps.id)">
            <div data-bs-toggle="modal" data-bs-target="#keepDetails" class="selectable">
              {{ keeps.name }}
            </div>
          </div>
          <img class=" profile-img" :title="keeps.creator?.name" :src="keeps.creator?.picture" alt="">
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { keepsService } from "../services/KeepsService";
import { logger } from "../utils/Logger";



export default {
  props: { keeps: { type: Object, required: true } },
  setup() {
    return {
      async setActiveKeep(keepId) {
        try {
          await keepsService.getOneKeep(keepId)

        } catch (error) {
          logger.error(error.message)
        }
      }




    };



  },

};
</script>


<style lang="scss" scoped>
.profile-img {
  height: 60px;
  width: 60px;
  border-radius: 100px;
}

// .masonry {
//   width: 1200px;
//   margin: 0px auto;
//   columns: 4;
//   column-gap: 10px;
// }




.box {
  // width: 235px;
  padding: 20px;
  // border: 1px solid rgb(100, 100, 100);
  break-inside: avoid;
  margin-bottom: 10px;
  height: 40vh;
  width: 100%;


}
</style>
