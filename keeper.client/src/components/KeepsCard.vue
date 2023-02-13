<template>

  <!-- <div > -->

  <div v-if="keeps" :key="keeps" :style="`background-image: url( ${keeps.img} )`" class="img-div rounded me-0 ">
    <section class="p-3 d-flex  align-items-end  justify-content-evenly ">
      <h5 @click="setActiveKeep(keeps.id)" data-bs-toggle="modal" data-bs-target="#keepDetails"
        class="selectable bg-bg rounded">
        {{ keeps.name }}
      </h5>
      <img v-if="keeps.creator" class="profile-img" :title="keeps.creator?.name" :src="keeps.creator?.picture"
        alt="https://thiscatdoesnotexist.com">

    </section>
  </div>

  <!-- </div> -->
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
      },

      // goToProfile(creator) {

      //   router.push({ name: 'Profile', params: { profileId: creator?.id } })
      // }


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

.img-div {
  background-position: center;
  background-size: cover;
  border: 3px rgba(37, 35, 35, 0.821) solid;
}

.bg-bg {
  background-color: rgba(0, 0, 0, 0.115);
  padding: 10px;
}

// .img-height {

//   $h: (random(400) + 100)+px;
//   height: $h;
//   line-height: $h;
//   row-gap: 50px;
// }

// @for $i from 1 through 36 {
//     div:nth-child(#{$i}) {
//       $h: (random(400) + 100)+px;
//       height: $h;
//       line-height: $h;
//     }
//   }

// .masonry {
//   width: 1200px;
//   margin: 0px auto;
//   columns: 4;
//   column-gap: 10px;
// }




// .box {
//   // width: 235px;
//   padding: 20px;
//   // border: 1px solid rgb(100, 100, 100);
//   // break-inside: avoid;
//   margin-bottom: 10px;
//   height: 40vh;
//   width: 100%;


// }
</style>
