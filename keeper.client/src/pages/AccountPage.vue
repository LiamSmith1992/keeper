<template>
  <div class="container-fluid">

    <div class="about text-center">
      <section class="row cover-img m-2 rounded">
        <div class="col-11 d-flex text-center">
        </div>
      </section>


      <img class="rounded-pill" :src="account.picture" alt="" />
      <h1>{{ account.name }}</h1>
      <p>{{ account.email }}</p>
    </div>

    <div class="text-center">
      <div>Vaults:{{ vaults.length }}</div>
      <div>Keeps:{{ keeps.length }}</div>
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
        <button v-if="v.creatorId == account.id" @click="deleteVault(v.id)" title="Delete Vault"
          class="mdi mdi-delete"></button>
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
        <button v-if="k.creatorId == account.id" @click="deleteKeep(k.id)"
          class="btn btn-danger mdi mdi-delete"></button>
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
import { computed, } from 'vue'
import { AppState } from '../AppState'
import VaultCard from "../components/VaultCard.vue"
import KeepsCard from "../components/KeepsCard.vue"
import Modal from "../components/Modal.vue"
import VaultForm from "../components/VaultForm.vue"
import KeepForm from "../components/KeepForm.vue"
import { vaultsService } from "../services/VaultsService"
import { logger } from "../utils/Logger"
import Pop from "../utils/Pop"
import { keepsService } from "../services/KeepsService"

export default {


  setup() {







    return {
      account: computed(() => AppState.account),
      coverImg: computed(() => `url(${AppState.account?.coverImg})`),
      vaults: computed(() => AppState.accountVaults),
      keeps: computed(() => AppState.accountKeeps),

      async deleteVault(vaultId) {
        try {
          const yes = await Pop.confirm('Delete Vault?')
          if (!yes) { return }
          await vaultsService.deleteVault(vaultId)
        } catch (error) {
          logger.error(error.message)
        }
      },
      async deleteKeep(keepId) {
        try {
          const yes = await Pop.confirm('Delete Keep?')
          if (!yes) { return }
          await keepsService.deleteKeep(keepId)
        } catch (error) {
          logger.error(error.message)
        }
      }


    }
  },
  components: { VaultCard, KeepsCard, Modal, VaultForm, KeepForm }
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
