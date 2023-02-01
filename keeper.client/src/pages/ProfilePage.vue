<template>
  <div class="container-fluid">

    <div v-if="account" class="about text-center">
      <section class="row cover-img m-2 rounded">
        <div class="col-11 d-flex text-center">
        </div>
      </section>


      <img class="rounded-pill" :src="account.picture" alt="" />
      <h1>{{ account.name }}</h1>
      <p>{{ account.email }}</p>
    </div>

    <div class="text-center">
      <div v-if="vaults">Vaults:{{ vaults.length }}</div>
      <div v-if="keeps">Keeps:{{ keeps.length }}</div>
    </div>

    <section v-if="vaults" class="row">
      <div class=" d-flex justify-content-center">
        <div class="underline col-3 d-flex justify-content-center">
          <h1>Vaults</h1>
          <button data-bs-toggle="modal" data-bs-target="#vaultForm" class=" ms-2 mdi mdi-plus btn btn-success"
            title="Create new vault"></button>
        </div>
      </div>
      <div v-for="v in vaults" class="col-3 m-2">

        <VaultCard :vaults="v" />

      </div>

    </section>

    <section v-if="keeps" class="row">
      <div class=" d-flex justify-content-center">
        <div class="underline col-3 d-flex justify-content-center">

          <h1>Keeps </h1>
          <button data-bs-toggle="modal" data-bs-target="#keepForm" title="Create new keep"
            class=" ms-2 mdi mdi-plus btn btn-success"></button>
        </div>
      </div>
      <div v-for="k in keeps" class="col-3 m-2">

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


  <h1>Profile Page</h1>

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
        debugger
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

<style scoped>
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
</style>
