<template>
  <div class="container">

    <div v-if="account" class="about text-center">
      <section class="row cover-img m-2 rounded">
        <div class="col-11 d-flex text-center">
        </div>
      </section>


      <img class="rounded-pill" :src="account.picture" alt="" />
      <h1>{{ account.name }}</h1>
    </div>

    <div class="text-center">
      <div v-if="vaults">Vaults:{{ vaults.length }}</div>
      <div v-if="keeps">Keeps:{{ keeps.length }}</div>
    </div>

    <section v-if="vaults" class="row">
      <div class=" d-flex justify-content-center">
        <div class="underline col-3 d-flex justify-content-center">
          <h1>Vaults</h1>


        </div>
      </div>
      <div v-for="v in vaults" class="col-3 align-items-evenly mt-4">

        <VaultCard :vaults="v" />

      </div>

    </section>

    <section v-if="keeps" class="row">
      <div class=" d-flex justify-content-center col-12">
        <div class="underline col-3 d-flex justify-content-center">

          <h1>Keeps </h1>

        </div>
      </div>

    </section>
    <section class="row">

      <div v-for="k in keeps" class="col-3  masonry-with-columns">

        <KeepsCard :keeps="k" />
      </div>
    </section>






    <Modal id="vaultForm">
      <VaultForm />
    </Modal>
    <div>

      <Modal id="keepForm">
        <KeepForm />
      </Modal>
    </div>
  </div>




</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import VaultCard from "../components/VaultCard.vue"
import KeepsCard from "../components/KeepsCard.vue"
import Modal from "../components/Modal.vue"


import { logger } from "../utils/Logger"
import { profilesService } from "../services/ProfilesService"
import { useRoute } from "vue-router"

export default {


  setup() {
    onMounted(() => {
      getProfileKeeps()
      getProfileVaults()
      getProfile()
    })
    const route = useRoute()

    async function getProfile() {
      try {

        await profilesService.getProfile(route.params.profileId)
      } catch (error) {
        logger.error(error.message)
      }
    }

    async function getProfileVaults() {
      try {
        await profilesService.getProfileVaults(route.params.profileId)
      } catch (error) {
        logger.error(error.message)
      }
    }

    async function getProfileKeeps() {
      try {
        await profilesService.getProfileKeeps(route.params.profileId)
      } catch (error) {
        logger.error(error.message)
      }
    }






    return {
      account: computed(() => AppState.profile),
      coverImg: computed(() => `url(${AppState.profile?.coverImg})`),
      vaults: computed(() => AppState.profileVaults),
      keeps: computed(() => AppState.profileKeeps),






    }
  },
  components: { VaultCard, KeepsCard, Modal }
}
</script>

<style scoped lang="scss">
img {
  max-width: 100px;
}

.cover-img {
  height: 40vh;
  background-image: v-bind(coverImg);
  object-fit: cover;
  width: 1;
  border: solid 3px black;
}

.underline {
  border-bottom: solid black 6px;
}

.keep-img {
  height: 25vh;
  widows: 100%;
  object-fit: cover;
  object-position: center;
}

.masonry-with-columns {
  columns: 4 200px;
  column-gap: 1rem;

  div {
    width: 150px;
    // background: #EC985A;
    color: white;
    margin: 1rem 1rem 1rem 0;
    display: inline-block;
    width: 100%;
    text-align: center;
    font-family: system-ui;
    // font-weight: 900;
    // font-size: 2rem;
  }

  @for $i from 1 through 36 {
    div:nth-child(#{$i}) {
      $h: (random(400) + 100)+px;
      height: $h;
      // line-height: $h;
    }
  }
}
</style>
