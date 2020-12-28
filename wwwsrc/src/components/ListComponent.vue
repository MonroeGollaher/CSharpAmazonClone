<template>
  <div class="list-component container-fluid">
    <div class="row justify-content-between align-items-center border-rounded bg-light shadow radius15 my-3 p-4">
      <div class="col-8 d-flex">
        <h5>{{ list.title }}</h5>
      </div>
      <div class="col-3 d-flex">
        <button @click="deleteList(list.id)" class="btn bg-transparent text-dark">
          <i class="fas fa-times"></i>
        </button>
        <button class="btn bg-transparent text-dark ml-1">
          <i class="far fa-edit"></i>
        </button>
        <button class="btn bg-transparent text-dark ml-1">
          <i class="fas fa-list-ol"></i>
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
import { listsService } from '../services/ListsService'
export default {
  name: 'ListComponent',
  props: ['listProp'],
  setup(props) {
    const state = reactive({
      editedList: {

      }
    })
    return {
      state,
      list: computed(() => props.listProp),
      profile: computed(() => AppState.profile),
      deleteList(id) {
        listsService.deleteList(id)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.radius15 {
  border-radius: 15px;
}
</style>
